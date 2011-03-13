methodsWithoutComments
	"Return a collection representing methods in the receiver which have no comments"

	| slips |
	slips _ OrderedCollection new.
	self changedClasses do:
		[:aClass |
		(self methodChangesAtClass: aClass name) associationsDo: 
				[:mAssoc | (#(remove addedThenRemoved) includes: mAssoc value) ifFalse:
					[(aClass selectors includes:  mAssoc key) ifTrue:
						[(aClass firstCommentAt: mAssoc key) isEmptyOrNil
								ifTrue: [slips add: aClass name , ' ' , mAssoc key]]]]].
	^ slips

	"Smalltalk browseMessageList: (Smalltalk changes methodsWithoutComments) name: 'methods lacking comments'"