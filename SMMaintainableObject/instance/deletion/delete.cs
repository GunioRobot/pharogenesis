delete
	"Disconnect from maintainers."

	super delete.
	maintainers ifNotNil: [
		maintainers copy do: [:m | self removeMaintainer: m]]