open3DSFile: fullFileName
	"Open a MoviePlayerMorph on the given file (must be in .3ds format)."
	| scene |
	scene _ B3DScene from3DS: (ThreeDSParser parseFileNamed: fullFileName).
	(B3DPrimitiveEngine isAvailable) ifFalse:[
		(self confirm:'WARNING: YOU HAVE NO REAL SUPPORT
FOR 3D!
Opening this guy in Morphic will EXTREMELY time consuming.
Are you sure you want to do this?!
(NO is probably the right answer :-)') ifFalse:[^scene inspect]].

		scene defaultCamera moveToFit: scene.
		(B3DSceneMorph new scene: scene) openInWorld.