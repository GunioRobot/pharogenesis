setUpExample
	| newDiscussion |
	newDiscussion _ Discussion new.
	newDiscussion title: 'pws'.
	newDiscussion description: 'Here is a space for talking about the Pluggable Web Server.'.
	CommentsTable at: 'pws' put: newDiscussion.

