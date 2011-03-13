howToUse
	"An instance of Delay responds to the message wait by suspending the
	caller's process for a certain amount of time. The duration of the pause
	is specified when the Delay is created with the message forMilliseconds: or
	forSeconds:. A Delay can be used again when the current wait has finished.
	For example, a clock process might repeatedly wait on a one-second Delay."