forkAndWait
	"Suspend current process while self runs"

	| semaphore |
	semaphore _ Semaphore new.
	[self ensure: [semaphore signal]] fork.
	semaphore wait.
