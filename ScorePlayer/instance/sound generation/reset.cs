reset

	super reset.
	tempo _ 120.0.
	self tempoOrRateChanged.
	done _ false.
	ticksSinceStart _ 0.
	"one index for each sound track, plus one for the ambient track..."
	trackEventIndex _ Array new: score tracks size+1 withAll: 1.
	tempoMapIndex _ 1.
	activeSounds _ OrderedCollection new.
	activeMIDINotes _ OrderedCollection new.
	score resetFrom: self.
	overallVolume ifNil: [overallVolume _ 0.5].
