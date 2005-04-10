cc: ind new: inTheSeg current: inTheImage fake: fakeCls refStrm: smartRefStream
	"Sort out all the cases and decide what to do.  Every Fake class is uncompacted before having insts converted.  As the segment is installed, instances of reshaped compact classes will have the wrong class.  Trouble cases:
	1) Existing class is compact in the segment and not compact here.  Make that compact, (error if that slot is used), load the segment.  If an class was just filed in, it is an existing class as far as we are concerned.
	2) A compact class has a different shape.  We created a Fake class.  Load the segment, with instances in the seg having the Wrong Class!!  Find the bad instancees, and copy them over to being the real class.
	3) An existing class is not compact in the segment, but is in the image.  Just let the new instance be uncompact.  That is OK, and never reaches this code.
	A class that is a root in this segment cannot be compact.  That is not allowed."

	(inTheImage == nil) & (fakeCls == nil) ifTrue: ["case 1 and empty slot" 
		inTheSeg becomeCompactSimplyAt: ind.  ^ true].
	
	(inTheImage == inTheSeg) & (fakeCls == nil) ifTrue: ["everything matches" 
		^ true].

	inTheImage ifNil: ["reshaped and is an empty slot"
		fakeCls becomeCompactSimplyAt: ind.  ^ true].
		"comeFullyUpOnReload: will clean up"

	(inTheSeg == String and:[inTheImage == ByteString]) ifTrue:[
		"ar 4/10/2005: Workaround after renaming String to ByteString"
		^true
	].

	"Is the image class really the class we are expecting?  inTheSeg came in as a DiskProxy, and was mapped if it was renamed!"
	inTheImage == inTheSeg ifFalse: [
		self inform: 'The incoming class ', inTheSeg name, ' wants compact class \location ', ind printString, ', but that is occupied by ', inTheImage name, '.  \This file cannot be read into this system.  The author of the file \should make the class uncompact and create the file again.' withCRs.
		^ false].

	"Instances of fakeCls think they are compact, and thus will say they are instances of the class inTheImage, which is a different shape.  Just allow this to happen.  Collect them and remap them as soon as the segment is installed."
	^ true