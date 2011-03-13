editFilterNamed: filterName filterExpr: oldExpr

	| newDefinition |
	newDefinition _ FillInTheBlank
		request:
'Enter a filter definition where "m" is the message being testing. The expression can send
"fromHas:", "toHas:", "ccHas:", "subjectHas:", "participantHas:", or "textHas:" to m to test for
inclusion of a string--or one of an array of strings--in a field. It can also test m''s time
and/or date and can combine several tests with logical operators. Examples:
 
     m fromHas: ''johnm''                       -- messages from johnm
     m participantHas: ''johnm''                -- messages from, to, or cc-ing johnm
     m textHas: #(squeak smalltalk java)      -- messages with any of these words
     m subjectHas: #(0 1 2 3 4 5 6 7 8 9)       -- numbers in lists treated as strings
 
NOTE: "textHas:" is very slow, since it must read the message from disk.'
		initialAnswer: oldExpr.
	newDefinition isEmpty ifTrue: [^''].
	CustomFilters at: filterName put: newDefinition.
	^filterName