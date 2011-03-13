translateBy: aPoint 
	"Answers a new Path whose elements are translated by aPoint. Does not
	affect the elements of this Path."

	| newPath |
	newPath _ Path new: self size.
	newPath form: self form.
	collectionOfPoints do: 
		[:element | 
		newPath add: 
			(element x + aPoint x) asInteger @ (element y + aPoint y) asInteger].
	^newPath