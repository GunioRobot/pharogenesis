uniqueInsertionPoints: aString
	"Find all occurances of '*append here'.  Make them lower case.  If
they don't have a number after them, assign one.  Don't use the same number
twice in this page.  Place ID can actually be any string."

| sourceStream targetStream ids char pos inside rest |
sourceStream := ReadStream on: aString.
targetStream := WriteStream on: String new.
ids _ Set new.	"id numbers that have been used"
[sourceStream atEnd	] whileFalse: [
	targetStream nextPut: (char _ sourceStream next).
	char == $* ifTrue: [
		pos _ sourceStream position.
		inside _ sourceStream upTo: $*.
		(inside asLowercase beginsWith: 'append here')
			ifFalse: [sourceStream position: pos.	"ignore"
				((inside = '') and: [sourceStream atEnd
not]) ifTrue: [
					targetStream nextPut: (char _
sourceStream next)]]	"Honor **"
			ifTrue: ["See if it has a number"
				targetStream nextPutAll: 'append here '.
				rest _ inside copyFrom: (13 min: inside
size +1) to: inside size.
				targetStream nextPutAll: (self unique: rest
in: ids); nextPut: $*]]].
^ targetStream contents

