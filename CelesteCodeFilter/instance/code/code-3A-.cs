code: aString
	"specify a new code string"
	code := aString.
	tester := Compiler evaluate: ('[ :m | ', code, ']')