veryDeepInner: deepCopier
	"Copy all of my instance variables.  Some need to be not copied at all, but shared.  	Warning!!  Every instance variable defined in this class must be handled.  We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

super veryDeepInner: deepCopier.
"hostView _ hostView.		Weakly copied"
stampForm _ stampForm veryDeepCopyWith: deepCopier.
canvasRectangle _ canvasRectangle veryDeepCopyWith: deepCopier.
palette _ palette veryDeepCopyWith: deepCopier.
currentColor _ currentColor veryDeepCopyWith: deepCopier.
ticksToDwell _ ticksToDwell veryDeepCopyWith: deepCopier.
rotationCenter _ rotationCenter veryDeepCopyWith: deepCopier.
registrationPoint _ registrationPoint veryDeepCopyWith: deepCopier.
newPicBlock _ newPicBlock veryDeepCopyWith: deepCopier.
emptyPicBlock _ emptyPicBlock veryDeepCopyWith: deepCopier.
action _ action veryDeepCopyWith: deepCopier.
paintingForm _ paintingForm veryDeepCopyWith: deepCopier.
dimForm _ dimForm veryDeepCopyWith: deepCopier.
buff _ buff veryDeepCopyWith: deepCopier.
brush _ brush veryDeepCopyWith: deepCopier.
paintingFormPen _ paintingFormPen veryDeepCopyWith: deepCopier.
formCanvas _ formCanvas veryDeepCopyWith: deepCopier.
picToBuff _ picToBuff veryDeepCopyWith: deepCopier.
brushToBuff _ brushToBuff veryDeepCopyWith: deepCopier.
buffToBuff _ buffToBuff veryDeepCopyWith: deepCopier.
buffToPic _ buffToPic veryDeepCopyWith: deepCopier.
rotationButton _ rotationButton veryDeepCopyWith: deepCopier.
scaleButton _ scaleButton veryDeepCopyWith: deepCopier.
strokeOrigin _ strokeOrigin veryDeepCopyWith: deepCopier.
cumRot _ cumRot veryDeepCopyWith: deepCopier.
cumMag _ cumMag veryDeepCopyWith: deepCopier.
undoBuffer _ undoBuffer veryDeepCopyWith: deepCopier.
lastEvent _ lastEvent veryDeepCopyWith: deepCopier.
currentNib _ currentNib veryDeepCopyWith: deepCopier.
enclosingPasteUpMorph _ enclosingPasteUpMorph.	"weakly copied"
                              