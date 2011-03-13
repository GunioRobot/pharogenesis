interpret
	"TestCClass3 new main"
	"(CCodeGenerator new initialize addClass: TestCClass3) codeString"

	0 to: 9 do: [ :currentBytecode |
		self dispatchOn: currentBytecode in: #(f1 f2 f2 f3 f3 f3 f4 f4 f5 f2).
	].
