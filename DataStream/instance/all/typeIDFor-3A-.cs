typeIDFor: anObject
	"Return the typeID for anObject's class.  This is where the tangle of objects is clipped to stop everything from going out.  
	Other classes can control their instance variables by defining objectToStoreOnDataStream.
	Morphs exclude objects not in their tree.  "

	| tt |
	tt _ anObject ioType.
	tt == #User ifTrue: [^ 13].	"HS Object whose class must be reconstructed"
	(anObject isKindOf: View) ifTrue: [^ 1 "nil"].	"blocked"
	(anObject isKindOf: Controller) ifTrue: [
		Transcript cr; show: 'Refused to store a Controller'. ^ 
		1 "nil"].
	(anObject isKindOf: CompiledMethod) ifTrue: [
		Transcript cr; show: 'Refused to store a CompiledMethod'. 
		^ 1 "nil"].
	(anObject isKindOf: BlockContext) ifTrue: [
		Transcript cr; show: 'Refused to store a BlockContext'. 
		^ 1 "nil"].
	(anObject isMorph) ifTrue: [
		(anObject couldBeOwnedBy: self rootObject) 
			ifTrue: [^ 9] "normal, might have nil owner"
			ifFalse: [^ 1 "Only let out members of our subtree"]].
	
	^ TypeMap at: anObject class ifAbsent: [9 "instance of any normal class"]	
"See DataStream initialize.  nil=1. true=2. false=3. a SmallInteger=4. a String=5. a Symbol=6.  a ByteArray=7. an Array=8. other = 9.  a Bitmap=11. a Metaclass=12. a Float=14.  a Rectangle=15. any instance that can have a short header=16."