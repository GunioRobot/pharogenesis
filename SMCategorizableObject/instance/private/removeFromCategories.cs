removeFromCategories
	"Remove me from all my categories."

	categories ifNotNil:[
		categories copy do: [:cat | self removeCategory: cat ]]