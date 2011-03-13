do: aBlock 
	"Refer to the comment in Collection|do:."

	map do:
		[:mapValue | aBlock value: (domain at: mapValue)]