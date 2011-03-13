mouseUp: evt in: aMorph

	| tuple project url |

	(aMorph boundsInWorld containsPoint: evt cursorPoint) ifFalse: [^self].
	tuple _ aMorph valueOfProperty: #projectParametersTuple ifAbsent: [^1 beep].
	project _ tuple fourth first.
	(project notNil and: [project world notNil]) ifTrue: [self closeMyFlapIfAny. ^project enter].
	url _ tuple third.
	url isEmptyOrNil ifTrue: [^1 beep].
	self closeMyFlapIfAny.
	ProjectLoading thumbnailFromUrl: url.

"---
	newTuple _ {
		aProject name.
		aProject thumbnail.
		aProject url.
		WeakArray with: aProject.
	}.
---"