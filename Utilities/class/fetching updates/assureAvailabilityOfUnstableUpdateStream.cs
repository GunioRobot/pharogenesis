assureAvailabilityOfUnstableUpdateStream
	"Check to see if the unstable Updates stream is in the list; if not, add it"

	UpdateUrlLists ifNil: [UpdateUrlLists _ OrderedCollection new].
	UpdateUrlLists do:
		[:pair | (pair first =  'Unstable Updates*') ifTrue: [^ self]].

	UpdateUrlLists addFirst: #('Unstable Updates*' #('squeak.cs.uiuc.edu/Squeak2.0/' 'update.squeakfoundation.org/external/'))

"Utilities assureAvailabilityOfUnstableUpdateStream"