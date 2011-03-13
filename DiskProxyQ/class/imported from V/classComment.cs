classComment
"An extended version of DiskProxy (which see) whose internalize method will
construct an object like DiskProxy does and then send it a sequence of
messages from a message queue.

Messages may be enqueued before the DiskProxyQ is saved on the
ReferenceStream. Example: ‘(TopPane new) label: w; model: x; menu: y’. This
saves creating a variety of highly specialized constructor methods.

Messages may also be enqueued by the DiskProxyQ between when its read from
disk and when it’s internalized to the desired object. The newly
read-in DiskProxyQ can catch messages like #objectContainedIn: (via
doesNotUnderstand:) and add them to the queue of messages to send to the
new object at internalization time. This matters a great deal to a network
of objects being read in from a ReferenceStream, since some objects get
internalized before other objects that they know.

You create a DiskProxyQ just like a DiskProxy, and optionally send it
#xxxQMessage: messages.

WARNING: The use of doesNotUnderstand: won’t work if you count on the not-understood
message’s result! DiskProxyQ>>doesNotUnderstand: cannot possibly return the
right result. It can’t even return the ‘self’ of the object being
internalized, since the whole point is that object hasn’t been created yet.
As a best bet, DiskProxyQ>>doesNotUnderstand: returns itself, which will
eventually be asked to #become: the object it internalizes to.

WARNING: The use of doesNotUnderstand: won’t work if ordinary DiskProxyQ
messages are mistaken for messages to enqueue for the proxied object, or
vice versa! Adding methods to future implementations of DiskProxyQ may screw
up exisitng DiskProxyQ objects! We might want to program specific DiskProxyQ
objects with message selectors to catch and enqueue when read in, but that
would be painful all around, and it’s not clear how to do it.
    Because of this, we (a) minimize the number of messages that a DiskProxyQ
responds to, and (b) begin all DiskProxyQ message selector names with ‘xxx’.
Still, DiskProxyQ inherits many methods from Object and a couple from APalObject!

My instance variables:
  • messageQueue -- either nil or an Array of objects to sendTo: the object I’m
        internalizing to (they’re generally of class Message or Symbol).

NOTE: The class method readDataFrom:size: anInteger deals with a subtle issue in
reading a network of objects. Recursively reading the a DiskProxyQ’s parts will
internalize them (comeFullyUpOnReload), possibly sending messages to the nascent
DiskProxyQ. I.e. the incomplete object receives (and enqueues) messages! When it
reads the DiskProxyQ’s message queue, it must combine that with the accumulated
queue.
    Rather than hard-wire the index of the inst var ‘messageQueue’, that method
ASSUMES that any non-nil inst var holds an Array to be concatenated with the filed
value.

-- 11/9/92 jhm, 12/1/92 jhm
"