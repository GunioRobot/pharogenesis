assureAbsenceOfUnstableUpdateStream
	"Check to see if the unstable Updates stream is in the list; if it is, *remove* it.  This is the *opposite* of #assureAvailabilityOfUnstableUpdateStream"

	UpdateUrlLists ifNil: [UpdateUrlLists _ OrderedCollection new].
	UpdateUrlLists _ UpdateUrlLists select:
		[:pair | pair first ~= 'Unstable Updates*']


"Utilities assureAbsenceOfUnstableUpdateStream"