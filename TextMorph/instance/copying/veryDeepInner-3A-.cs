veryDeepInner: deepCopier 
	"Copy all of my instance variables. Some need to be not copied at all, but shared.
	Warning!! Every instance variable defined in this class must be handled.
	We must also implement veryDeepFixupWith:.  See DeepCopier class comment."

	super veryDeepInner: deepCopier.
	textStyle _ textStyle veryDeepCopyWith: deepCopier.
	text _ text veryDeepCopyWith: deepCopier.
	wrapFlag _ wrapFlag veryDeepCopyWith: deepCopier.
	paragraph _ paragraph veryDeepCopyWith: deepCopier.
	editor _ editor veryDeepCopyWith: deepCopier.
	container _ container veryDeepCopyWith: deepCopier.
	predecessor _ predecessor.
	successor _ successor