replaceFields: fieldsArray
	"Replace existing fields or append to the header. fieldsArray is an array of entire header lines."

	| found fields |
	fields _ Dictionary new.
	fieldsArray do: [:f | fields at: (f copyUpTo: $:) asLowercase put: f withoutTrailingBlanks].
	found _ Set new.
	self rewriteFields:
		[ :fName :fValue | | fieldString |
			fieldString _ fields at: fName asLowercase ifAbsent: [].
			fieldString ifNotNil: [
				found add: fName asLowercase.
				(fieldString last = $:)
					ifTrue: ['']
					ifFalse: [fieldString]]]
		append: [String streamContents: [:append |
			fields keysAndValuesDo: [:fk :fv | 
				((found includes: fk) or: [fv last = $:])
					ifFalse: [append nextPutAll: fv; cr]]]].

