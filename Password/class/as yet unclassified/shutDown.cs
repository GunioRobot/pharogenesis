shutDown
	"Forget all cached passwords, so they won't stay in the image"

	self withAllSubclasses do: [:cls |
		cls allInstancesDo: [:each | each cache: nil]].