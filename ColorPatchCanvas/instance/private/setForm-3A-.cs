setForm: aForm
	"Initialize the receiver to act just as a FormCanvas"
	super setForm: aForm.
	stopMorph _ nil.
	doStop _ false.
	foundMorph _ false.