zapSourcePointer

	"clobber the source pointer since it will be wrong"
	0 to: 3 do: [ :i | self at: self size - i put: 0].
