testReplaceFromToWithStartingAt
	| string |

	string := 'abcd' copy.
	string replaceFrom: 1 to: 3 with: 'lmnop' startingAt: 1.
	self assert: string = 'lmnd'.
	
	string := 'abcd' copy.
	string replaceFrom: 1 to: 3 with: 'lmnop' startingAt: 2.
	self assert: string = 'mnod'.
	
	string := 'abcd' copy.
	string replaceFrom: 2 to: 3 with: 'lmnop' startingAt: 1.
	self assert: string = 'almd'.