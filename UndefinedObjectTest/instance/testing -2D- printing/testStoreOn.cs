testStoreOn
	| string |

	string := String streamContents: [:stream | nil storeOn: stream].
	self assert: ((Compiler evaluate: string) = nil).