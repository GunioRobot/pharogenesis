initialize
	"EToyParameters initialize"
	TransparentPlayfield ifNil: [TransparentPlayfield _ true].  "if false manually, leave it there"
	TransparentPlayfield ifFalse:
		[RunningPlayfieldColor _  Color r: 0.861 g: 1.0 b: 0.722.
		FrozenPlayfieldColor _  Color r: 1.0 g: 0.767 b: 0.767.
		RunningPlayfieldBorderColor _ RunningPlayfieldColor.
		FrozenPlayfieldBorderColor _ Color  red lighter].
	CautionBeforeClosing _ true.
	KidsMode _ false.
	GoButtonInScriptor _ false.
	CoverSpiralPt _ 0@45.
	BadgePicPt _ 0@195.
	ImagiPicPt _ 0@54.
	StudioPicPt _ 10@393.
	WaltPicPoint _ -13 @ 52
