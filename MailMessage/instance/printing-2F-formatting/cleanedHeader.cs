cleanedHeader
	"Reply with a cleaned up version email header.  First show fields people would normally want to see (in a regular order for easy browsing), and then any other fields not explictly excluded"

	| new priorityFields omittedFields |

	new _ WriteStream on: (String new: text size).

	priorityFields _ #('Date' 'From' 'Subject' 'To' 'Cc').
	omittedFields _ MailMessage omittedHeaderFields.

	"Show the priority fields first, in the order given in priorityFields"
	priorityFields do: [ :pField |
		"We don't check whether the priority field is in the omitted list!"
		self headerFieldsNamed: pField do:
			[: fValue | new nextPutAll: pField, ': ', fValue decodeMimeHeader; cr]].

	"Show the rest of the fields, omitting the uninteresting ones and ones we have already shown"
	omittedFields _ omittedFields, priorityFields.
	self fieldsFrom: (ReadStream on: text) do:
		[: fName : fValue |
		((fName beginsWith: 'x-') or:
			[omittedFields anySatisfy: [: omitted | fName sameAs: omitted]])
				ifFalse: [new nextPutAll: fName, ': ', fValue; cr]].

	^new contents