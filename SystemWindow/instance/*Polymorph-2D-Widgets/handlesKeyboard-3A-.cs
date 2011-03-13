handlesKeyboard: evt
	"Return true if the receiver wishes to handle the given keyboard event"
	
	(super handlesKeyboard: evt) ifTrue: [^true].
	^evt commandKeyPressed and: [
		evt keyCharacter = Character arrowLeft or: [
		evt keyCharacter = Character arrowRight or: [
		evt keyCharacter = Character delete or: [
		evt keyCharacter = $w]]]]