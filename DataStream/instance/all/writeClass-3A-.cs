writeClass: aClass
	"PRIVATE -- For now, no classes may be written.  HyperSqueak user unique classes have not state other than methods and should be reconstructed.  Could put standard fileOut code here if necessary.  ."
	"Just halt for now -- 9/20/96 di."
	self error: 'Should not be trying to write a class'
"
	Obj classPool at: #ErrorHolder put: aClass.
	Transcript cr; show: 'The class ', aClass printString,' is trying to be written out.  See Obj class variable ErrorHolder.'.
"