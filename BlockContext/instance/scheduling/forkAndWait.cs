forkAndWait
	"Suspend current process and execute self in new process, when it completes resume current process"

	| semaphore |
	semaphore _ Semaphore new.
	[self ensure: [semaphore signal]] fork.
	semaphore wait.
