initialize
	"Initialize account."

	super initialize.
	initials _ signature _ advogatoId _ ''.
	isAdmin _ false.
	objects _ OrderedCollection new.
	coObjects _ OrderedCollection new