initialize
	"Initialize account."

	super initialize.
	initials := signature := advogatoId := ''.
	isAdmin := false.
	objects := OrderedCollection new.
	coObjects := OrderedCollection new