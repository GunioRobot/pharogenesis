setupFood: aPatch
	"Create several food caches."

	aPatch set: 'food' to: 0.  "patch default is no food"

	((aPatch distanceTo: 15@15) <= 1 or:
	 [(aPatch distanceTo: 80@20) <= 1 or:
	 [(aPatch distanceTo: 25@80) <= 1 or:
	 [(aPatch distanceTo: 70@70) <= 1]]]) ifTrue: [
		aPatch set: 'food' to: 10.
		aPatch color: Color red].

