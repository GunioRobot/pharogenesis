processMotdStart: aMessage
	"MOTD is being transmitted"
	motdBeingBuilt _ WriteStream on: String new.