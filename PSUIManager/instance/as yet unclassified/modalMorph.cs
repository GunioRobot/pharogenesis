modalMorph
	"Answer the morph that should be used to handle modality."
	
	|sender receiver foundWorld|
	sender := thisContext sender.
	foundWorld := false.
	[foundWorld or: [sender isNil]] whileFalse: [
		receiver := sender receiver.
		((receiver isKindOf: TheWorldMainDockingBar) or: [
			((receiver isKindOf: TheWorldMenu) or: [sender selector = #putUpWorldMenu:]) or: [
				receiver == World and: [sender selector == #handleEvent: or: [sender selector == #findWindow:]]]])
			ifTrue: [	foundWorld := true]
			ifFalse: [sender := sender sender]].
	foundWorld ifTrue: [^receiver world ifNil: [World]].
	^SystemWindow topWindow ifNil: [World]