# Git Conventions

This document outlines conventions for git usage in COMP2160.

- [Git Conventions](#git-conventions)
- [Git Ignore](#git-ignore)
- [Unity](#unity)

# Git Ignore

Use the standard Unity `.gitignore` file provided at:

https://github.com/github/gitignore/blob/master/Unity.gitignore

Rename this to `.gitignore` and copy it into the Unity project directory:

```
unity-game-repository/
  My Unity Project/
    .gitignore   <-- FILE GOES HERE
    Assets/
    Library/
    Packages/
    ProjectSettings/
    Temp/
```

# Workflow

We advocate the [feature-based branching workflow](https://www.atlassian.com/git/tutorials/using-branches) described in lectures. The `main` branch is reserved for stable, tested code. No work-in-progress commits should be made in the `main` branch. 

Features are developed in feature-specific branches, which may include work-in-progress code. Features are only merged into `main` after testing and code-review.

# Commit messages

Commit whenever you have completed a meaningful chunk of work. E.g., when you have:
* Implemented a new feature.
* Fixed a bug.
* Completed a code refactor.
* Added new packages or assets to your project.
* Completed other project housekeeping (e.g. code review).
A
lso, always commit work in progress before walking away from your computer.

Commit messages should follow the [Conventional Commits](https://www.conventionalcommits.org/en/v1.0.0/) standard. Short commit messages should have the format:
```
<type>[optional scope]: <description>
```
Where `<type>` is one of:
* `asset`: Adding new assets to the Unity project. 
* `chore`: Project management chores, e.g. making a new Unity project, updating gitignore, 
* `docs`: Documentation only changes
* `feat`: A new feature
* `fix`: A bug fix
* `perf`: A code change that improves performance
* `refactor`: A code change that neither fixes a bug nor adds a feature
* `style`: Changes that do not affect the meaning of the code (white-space, formatting, missing semi-colons, etc)
* `test`: Adding missing tests or correcting existing tests

The optional `[scope]` field can refer to a particular part of the codebase affected e.g. `gameplay`, `ui`, `analytics`, `editor`, etc.

The `description` is a short summary of the code changes and is typically written in imperative form, as a statement of what this commit does.

```
docs: Update ERD to reflect new architecture.
feat[ui]: Add score display.
fix[gameplay]: Prevent enemies from moving through walls.
asset[ui]: Add fonts for main menu.
chore[editor]: Update Unity to version 6.5.11f1.
```

Work-in-progress commits are made while the chunk being implemented is still incomplete, but you need to back up your work (e.g. when you need to step away from your computer).

These should be clearly labelled as `WIP` to denote that they are currently in a broken or incomplete state:
```
WIP refactor[analytics]: Move to event-based architecture.
```
# Unity best practices

## Prefabs

Use prefabs extensively to avoid merge conflicts when editing scene files. **Every object** in the scene should be a prefab, even if there is only one instance of it. Edits made in the Inspector should be performed on the prefab, not on the instance in the scene. This isolates changes to individual prefab files.

## Scenes

Create separate scenes for:
* Published content, to be included in the game build (e.g. shell menus, levels, etc),
* QA scenes for testing specific features,
* Workspaces for each developer to experiment in.

Avoid doing development in published scenes. These scenes should only be edited when new content is added to the main release build.

# Asset Management

For this unit, we will be using the standard Git tool for managing assets (e.g. sprites, audio, models, textures, etc) rather than specialised tools such as Git LFS. This is not a good solution for projects where art is developed alongside the game source, but will suffice for assignments.