scaleBy: aPoint 
	"Answers a new Path scaled by aPoint. Does not affect the current data in 
	this Path."

	| newPath |
	newPath _ Path new: self size.
	newPath form: self form.
	collectionOfPoints do: 
		[:element | 
		newPath add: 
				(aPoint x * element x) asInteger @ (aPoint y * element y) asInteger].
	^newPath