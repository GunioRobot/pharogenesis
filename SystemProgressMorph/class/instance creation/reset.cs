reset
	"SystemProgressMorph reset"
	UniqueInstance ifNotNil: [UniqueInstance delete].
	UniqueInstance := nil.