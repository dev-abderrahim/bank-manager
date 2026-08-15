{
  description = "C# .NET development environment";

  inputs = {
    nixpkgs.url = "github:NixOS/nixpkgs/nixpkgs-unstable";
  };

  outputs = { self, nixpkgs }:
    let
      supportedSystems = [ "x86_64-linux" ];
      forAllSystems = nixpkgs.lib.genAttrs supportedSystems;
    in {
      devShells = forAllSystems (system:
        let
          pkgs = import nixpkgs { inherit system; };
        in {
          default = pkgs.mkShell {
            packages = [ 
		pkgs.dotnet-sdk_10 
		];

            shellHook = ''
              export DOTNET_ROOT="${pkgs.dotnet-sdk_10}"
              export PATH="$DOTNET_ROOT/tools:$PATH"
              echo "dotnet $(dotnet --version) loaded"
            '';
          };
        }
      );
    };
}
