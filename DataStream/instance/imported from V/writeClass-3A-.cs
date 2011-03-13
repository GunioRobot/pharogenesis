writeClass: aClass
	"PRIVATE -- For now, no classes may be written.  HyperSqueak user unique classes have not state other than methods and should be reconstructed.  Could put standard fileOut code here is necessary.  7/29/96 tk."

	Obj classPool at: #ErrorHolder put: aClass.
	Transcript cr; show: 'The class ', aClass printString,' is trying to be written out.  See Obj class variable ErrorHolder.'.
	"do nothing"