processMotd: aMessage
	"a new line has arrived for the MOTD"
	motdBeingBuilt nextPutAll: aMessage arguments second.
	motdBeingBuilt cr.