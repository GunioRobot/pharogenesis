initializeTagTable
	"Create and return a new SWF tag table"
	"FlashFileReader initializeTagTable"
	TagTable := Array new: 50.
	TagTable atAllPut: #processUnknown:.
	#(
	(processEnd:					0)
	(processShowFrame:			1)
	(processDefineShape:		2)
	(processFreeCharacter:		3)
	(processPlaceObject:			4)
	(processRemoveObject:		5)
	(processDefineBits:			6)
	(processDefineButton:		7)
	(processJPEGTables:			8)
	(processSetBackgroundColor:	9)
	(processDefineFont:			10)
	(processDefineText:			11)
	(processDoAction:			12)
	(processDefineFontInfo:		13)
	"Event sound tags."
	(processDefineSound:		14)
	(processStartSound:			15)
	(processDefineButtonSound:	17)
	(processSoundStreamHead:	18)
	(processSoundStreamBlock:	19)
	(processDefineBitsLossless:	20)	"A bitmap using lossless zlib compression."
	(processDefineBitsJPEG2:		21)	"A bitmap using an internal JPEG compression table"
	(processDefineShape2:		22)
	(processDefineButtonCxform:	23)
	(processProtect:				24)	"This file should not be importable for editing."

	"These are the new tags for Flash 3."
	(processPlaceObject2:			26)	"The new style place w/ alpha color transform and name."
	(processRemoveObject2:		28)	"A more compact remove object that omits the character tag (just depth)."
	(processDefineShape3:		32)	"A shape V3 includes alpha values."
	(processDefineText2:			33) "A text V2 includes alpha values."
	(processDefineButton2:		34)	"A button V2 includes color transform) alpha and multiple actions"
	(processDefineBitsJPEG3:		35)	"A JPEG bitmap with alpha info."
	(processDefineBitsLossless2:	36)	"A lossless bitmap with alpha info."
	(processDefineSprite:		39) "Define a sequence of tags that describe the behavior of a sprite."
	(processNameCharacter:		40) "Name a character definition, character id and a string, (used for buttons) bitmaps, sprites and sounds)."
	(processFrameLabel:			43) "A string label for the current frame."
	(processSoundStreamHead2:	45) "For lossless streaming sound, should not have needed this..."
	(processDefineMorphShape:	46) "A morph shape definition"
	(processDefineFont2:			48)
	) do:[:spec|
			TagTable at: spec last+1 put: spec first.
	].