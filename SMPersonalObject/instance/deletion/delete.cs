delete
	"Disconnect from owner and maintainers."

	super delete.
	owner removeObject: self.
	maintainers ifNotNil: [
		maintainers copy do: [:m | self removeMaintainer: m]]