reOpen
	"Close this package loader, probably because it has been updated,
	and open a new one."

	self inform: 'This package loader has been upgraded and will be closed and reopened to avoid strange side effects.'.
	self delete.
	SMLoader open