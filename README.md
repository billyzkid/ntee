ntee
====

Like Unix tee, ntee is yet another Windows tee utility that echos standard input back to standard output and then redirects it to one or more files.

Examples
--------

To echo and redirect the output of the `time` command to a new file:

	time | ntee log.txt

By default, ntee will overwrite existing files. To append instead:

	dir | ntee /a log.txt

Enjoy!