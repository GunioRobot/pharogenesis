setExternalHandle: aHandle on: aDisplay
	"Initialize the receiver from the given external handle"
	display _ aDisplay.
	bits _ aHandle.
	(display notNil and:[bits notNil]) ifTrue:[
		"Now we can find out what the format of the receiver is"
		width _ self actualWidth.
		height _ self actualHeight.
		depth _ self actualDepth.
	].