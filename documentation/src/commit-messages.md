# Commit Message

We follow six of the seven rules of great commit messages

1. Separate subject from body with a blank line
2. Limit the subject line to 50 characters
3. Capitalize the subject line
4. Do not end the subject line with a period
5. Use the imperative mood in the subject line 
6. Use the body to explain WHAT and WHY vs. HOW

The rule "Wrap the body at 72 characters" does not apply to TFVC users, as Visual Studio takes care of wrapping the body correctly.

In addition, we prepend the commit message with the module that has been worked on, followed by a colon. This prefix does not count towards the subject line character limit.

## Language
Commit messages are written in English.

**Bad example**: Added feature  
**Good example**: Document Editor: Add copy-pasting feature

**Bad example**: A position with a parts list can be inserted in your own parts list, which leads to a program crash.  
**Good example**: Catalog: Fix Crash happening in recursive parts list ↵  
A position which had itself a parts list could wrongly be inserted into a parts list.