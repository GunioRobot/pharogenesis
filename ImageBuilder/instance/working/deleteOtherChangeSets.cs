deleteOtherChangeSets
	"delete other unwanted changesets"
	#('Games' 'Squeak in 3D' 'VersionNumber1' 'MCInstaller1' 'SMBase1' 'SMLoader1' 'SmaCC-Runtime1' 'SUnit1' 'Tools' 'Compiler1' 'SARInstallerFor36-nk' 'MC1' 'Monticello1' 'MCInstaller' 'Yaxo-2' 'MC2' 'Scamper.cs' 'Network-HTML.cs' 'Skeleton-Base.st' 'Morphic-Games.st' 'Balloon3D.1.0.3.sar' 'Graphics-Tools.st' 'Graphics-External.st' 'Balloon3D-Constants.st' 'Balloon3D-Kernel.st' 'Balloon3D-Plugins.st' 'Balloon3D-Import.st' 'Balloon3D-VRML.st' 'Balloon3D-Pooh.st' 'Balloon3D-Morphic.st' 'Balloon3D-Tutorial.st' 'Balloon3D-Wonderland.st' 'Balloon3D-Packaging.st' 'MC3' 'DefaultExternalDropHandler-dgd' 'MC4' 'VMMaker3-6g2.sar' 'VMMaker' 'MC5' 'MC6' 'MC7' 'MC8')
		do: [:each | 
			| cs | 
			cs := ChangeSorter changeSetNamed: each.
			cs isNil
				ifFalse: [ChangeSorter removeChangeSet: cs]]