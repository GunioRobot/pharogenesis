testIsSystemWindow
	"test isSystemWindow"
	self deny: Object new isSystemWindow.
	self assert: SystemWindow new isSystemWindow.
	self assert: WorldWindow new isSystemWindow.