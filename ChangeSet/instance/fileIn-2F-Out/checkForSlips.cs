checkForSlips
	"Return a collection of method refs with possible debugging code in them."
	| slips method |
	slips _ OrderedCollection new.
	self changedClasses do:
		[:aClass |
		(self methodChangesAtClass: aClass name) associationsDo: 
				[:mAssoc | (#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
					[method _ aClass compiledMethodAt: mAssoc key ifAbsent: [nil].
					method ifNotNil:
						[method hasReportableSlip
							ifTrue: [slips add: aClass name , ' ' , mAssoc key]]]]].
	^ slips