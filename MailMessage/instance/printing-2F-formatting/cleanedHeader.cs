cleanedHeader
	"Reply with a cleaned up version email header.  First show fields people would normally want to see (in a regular order for easy browsing), and then any other fields not explictly excluded"

	"Note: Capitalization of letters in a field name is not exactly preserved"

	| new priorityFields omittedFields |

	new _ WriteStream on: (String new: text size).

	priorityFields _ #('date' 'from' 'subject' 'to' 'cc').
	omittedFields _ MailMessage omittedHeaderFields.

	"Show the priority fields first, in the order given in priorityFields"
	priorityFields do: [ :pField |
		"We don't check whether the priority field is in the omitted list!"
		self headerFieldsNamed: pField do:
			[: fValue | new nextPutAll: pField capitalized, ': ', fValue; cr]].

	"Show the rest of the fields, omitting the uninteresting ones and ones we have already shown"
	self fieldsFrom: (ReadStream on: text) do:
		[: fName : fValue |
		 ((omittedFields includes: fName) or: [ priorityFields includes: fName]) ifFalse:
				[new nextPutAll: fName capitalized.
				 new nextPutAll: ': '.
				 new nextPutAll: fValue; cr]].

	^new contents