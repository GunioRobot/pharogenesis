test2
	"Checking construction of model:
	- verify test for circular dependencies (not allowed)."

	"Circular1rel has a conf to Circular2rel, which in turn has one back."
	| circular1rel circular2rel circular3rel |
	circular1rel := (map packageWithName: 'Circular1') lastRelease.
	circular2rel := (map packageWithName: 'Circular2') lastRelease.
	circular3rel := (map packageWithName: 'Circular3') lastRelease.

	(circular1rel publisher: goranAccount; addConfiguration)
		addRequiredRelease: circular2rel.

	(circular2rel publisher: goranAccount; addConfiguration)
		addRequiredRelease: circular3rel.
	
	self should: [
		(circular3rel publisher: goranAccount; addConfiguration)
			addRequiredRelease: circular1rel]
		raise: Error