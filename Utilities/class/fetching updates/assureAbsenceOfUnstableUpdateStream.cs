assureAbsenceOfUnstableUpdateStream
	"Check to see if the unstable Updates stream is in the list; if it is, *remove* it.  This is the *opposite* of #assureAvailabilityOfUnstableUpdateStream"

	UpdateUrlLists ifNil: [UpdateUrlLists := OrderedCollection new].
	UpdateUrlLists := UpdateUrlLists select:
		[:pair | pair first ~= 'Unstable Updates*']


"Utilities assureAbsenceOfUnstableUpdateStream"