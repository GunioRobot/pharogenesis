obsolete
	"Change the receiver to an obsolete class by changing its name to have
	the prefix -AnObsolete-."

	name _ 'AnObsolete' , name.
	classPool _ Dictionary new.
	self class obsolete.
	super obsolete